#!/bin/bash

# Get the script's directory and project root
SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/../../" && pwd)"

# Paths relative to project root
CONFIG_FILE="$SCRIPT_DIR/config.yaml"
OUTPUT_DIR="$ROOT_DIR/packages/output"
LOCAL_NUGET_SOURCE="$HOME/.nuget/local"

# Ensure yq is installed
if ! command -v yq &> /dev/null; then
    echo "❌ Error: 'yq' is required but not installed."
    echo "Install it via: sudo apt install yq (Ubuntu) or brew install yq (MacOS)."
    exit 1
fi

# Ensure the output directory and NuGet repository exist
mkdir -p "$OUTPUT_DIR"
mkdir -p "$LOCAL_NUGET_SOURCE"

# Function to display help
show_help() {
    echo "📖 Usage: ./build.sh {build|pack|publish|clean|help}"
    echo ""
    echo "Available commands:"
    echo "  build    - Build all projects from config.yaml"
    echo "  pack     - Build and package all projects"
    echo "  publish  - Build, package, and publish all projects to local NuGet repo"
    echo "  clean    - Clean all projects and remove output files"
    echo "  help     - Show this help message"
    echo ""
    exit 0
}

# Function to build a project
build() {
    local project_path="$1"
    local package_version="$2"
    local abs_project_path="$ROOT_DIR/$project_path"

    echo "🔨 Building: $abs_project_path (Version: $package_version)"
    dotnet build "$abs_project_path" --configuration Release -p:Version="$package_version"
}

# Function to package a project with README.md
pack() {
    local project_path="$1"
    local package_version="$2"
    local abs_project_path="$ROOT_DIR/$project_path"
    # shellcheck disable=SC2155
    local project_dir="$(dirname "$abs_project_path")"  # Get project directory
    local abs_readme_path="$project_dir/README.md"      # Assume README.md is in the same directory
    # shellcheck disable=SC2155
    local package_name=$(basename "$abs_project_path" .csproj)  # Extract package name
    local package_file="$OUTPUT_DIR/$package_name.$package_version.nupkg"
    
    # Check if README.md exists
    if [[ -f "$abs_readme_path" ]]; then
        echo "📝 Including README.md: $abs_readme_path"
        dotnet pack "$abs_project_path" --configuration Release --output "$OUTPUT_DIR" -p:Version="$package_version"
    else
        echo "⚠️ WARNING: README.md not found in $project_dir. Packaging without README."
        dotnet pack "$abs_project_path" --configuration Release --output "$OUTPUT_DIR" -p:Version="$package_version"
    fi

#    # ✅ Verify package integrity after packing
    if [[ -f "$package_file" ]]; then
        echo "✅ Verifying package: $package_file"
        if ! dotnet nuget verify --all "$package_file"; then
            echo "⚠️ WARNING: Package verification failed (but continuing)."
        fi
    fi
}

# Function to publish a NuGet package
publish() {
    local package_name="$1"
    local package_version="$2"
    local nupkg_path="$OUTPUT_DIR/$package_name.$package_version.nupkg"

    if [[ ! -f "$nupkg_path" ]]; then
        echo "❌ Error: Package file not found: $nupkg_path"
        exit 1
    fi

    echo "🚀 Publishing: $package_name (Version: $package_version)"
    dotnet nuget add source "$LOCAL_NUGET_SOURCE" --name local || true
    dotnet nuget push "$nupkg_path" --source "$LOCAL_NUGET_SOURCE" --skip-duplicate
}

# Function to clean a project
clean() {
    local project_path="$1"
    local abs_project_path="$ROOT_DIR/$project_path"
    
    echo "🧹 Cleaning: $abs_project_path"
    dotnet clean "$abs_project_path" --configuration Debug
    dotnet clean "$abs_project_path" --configuration Release

    rm -rf "$OUTPUT_DIR"
}

# Process each package from config.yaml
process_packages() {
    local command="$1"

    if [[ ! -f "$CONFIG_FILE" ]]; then
        echo "❌ Error: Config file not found at $CONFIG_FILE"
        exit 1
    fi

    yq e '.packages[] | .name + " " + .version + " " + .path' "$CONFIG_FILE" | while read -r line; do
        package_name=$(echo "$line" | awk '{print $1}')
        package_version=$(echo "$line" | awk '{print $2}')
        project_path=$(echo "$line" | awk '{print $3}')

        case "$command" in
            build) build "$project_path" "$package_version" ;;
            pack) build "$project_path" "$package_version" && pack "$project_path" "$package_version" ;;
            publish) build "$project_path" "$package_version" && pack "$project_path" "$package_version" && publish "$package_name" "$package_version" ;;
            clean) clean "$project_path" ;;
            *) show_help ;;
        esac
    done
}

# Check if no parameter was given or if user asks for help
if [[ -z "$1" || "$1" == "help" ]]; then
    show_help
fi

# Execute command for all packages
process_packages "$1"
