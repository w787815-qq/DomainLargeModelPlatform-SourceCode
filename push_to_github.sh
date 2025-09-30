#!/bin/bash

# Shell script to submit extracted C# code to GitHub
# Prerequisites: git and gh (GitHub CLI) must be installed
# Usage: Save extracted .cs files in ~/DomainLargeModelPlatform-SourceCode, then run this script

# Exit on error
set -e

# Variables
REPO_NAME="DomainLargeModelPlatform-SourceCode"
REPO_DIR="$HOME/$REPO_NAME"
GITHUB_USER="w787815"
REPO_URL="https://github.com/$GITHUB_USER/$REPO_NAME.git"

# Check if git is installed
if ! command -v git &> /dev/null; then
    echo "Error: Git is not installed."
    echo "Install Git:"
    echo "  On Ubuntu/Debian: sudo apt-get install git"
    echo "  On macOS: brew install git"
    echo "  On Windows: Download from https://git-scm.com/downloads"
    exit 1
fi

# Check if GitHub CLI is installed
if ! command -v gh &> /dev/null; then
    echo "Error: GitHub CLI (gh) is not installed."
    echo "Install GitHub CLI:"
    echo "  On Ubuntu/Debian: sudo apt install gh"
    echo "  On macOS: brew install gh"
    echo "  On Windows: Download from https://cli.github.com"
    exit 1
fi

# Check if directory exists, create if not
if [ ! -d "$REPO_DIR" ]; then
    mkdir -p "$REPO_DIR"
fi

# Navigate to directory
cd "$REPO_DIR"

# Initialize git repository if not already initialized
if [ ! -d ".git" ]; then
    git init
fi

# Create folder structure for code files
mkdir -p Models Services UIs

# Check if code files exist (assumes user has saved them)
# Note: User must manually save extracted .cs files from previous response
EXPECTED_FILES=(
    "Models/ResourceMonitoringModel.cs"
    "Services/ResourceMonitoringService.cs"
    "UIs/ResourceMonitoringUi.cs"
    "UIs/DataPreprocessingUi.cs"
    "Services/DataPreprocessingService.cs"
    "Models/DataPreprocessingModel.cs"
    # Add other files here if full extraction was provided
)

for file in "${EXPECTED_FILES[@]}"; do
    if [ ! -f "$file" ]; then
        echo "Warning: $file not found in $REPO_DIR/$file"
        echo "Please ensure all extracted .cs files are saved in the correct folders."
    fi
done

# Create a .gitignore file for C# projects
cat << EOF > .gitignore
# C# build artifacts
bin/
obj/
*.csproj.user
*.suo
*.user
*.userosscache
*.sln.docstates

# Visual Studio files
.vscode/
.idea/
*.log
EOF

# Create a README.md
cat << EOF > README.md
# Domain Large Model Platform Source Code

This repository contains the extracted C# source code for a domain-specific large model training and fine-tuning platform. The code includes modules for resource monitoring, data preprocessing, and related services/UI components.

## Folder Structure
- **Models/**: Data models and database interactions
- **Services/**: Business logic and service layers
- **UIs/**: User interface components (Windows Forms)

## Note
The code is extracted as-is from a provided document and may contain syntax errors or incomplete implementations. It requires cleanup and validation before use.

## Setup
1. Clone the repo: \`git clone $REPO_URL\`
2. Open in Visual Studio or preferred C# IDE.
3. Restore NuGet packages (e.g., Microsoft.EntityFrameworkCore, Newtonsoft.Json).
4. Configure database connection for SQL operations.
EOF

# Check if GitHub repo exists, create if not
gh repo view "$GITHUB_USER/$REPO_NAME" &> /dev/null || {
    echo "Creating GitHub repository: $REPO_NAME"
    gh repo create "$REPO_NAME" --private --source=. --remote=origin
}

# Add remote if not set
if ! git remote | grep -q origin; then
    git remote add origin "$REPO_URL"
fi

# Add all files
git add .

# Commit changes
git commit -m "Initial commit: Add extracted C# source code for domain large model platform"

# Push to GitHub
echo "Pushing to GitHub..."
echo "Note: You may need a Personal Access Token (PAT) for authentication."
echo "Generate one at https://github.com/settings/tokens with 'repo' scope."
git push --set-upstream origin main || {
    echo "Error: Push failed. Ensure you have authenticated with GitHub."
    echo "Run 'gh auth login' or use a PAT with 'git push'."
    exit 1
}

echo "Success: Code has been pushed to $REPO_URL"
echo "Verify at: https://github.com/$GITHUB_USER/$REPO_NAME"