# PowerShell deployment script for Problem Jasia Retro
param(
    [string]$VersionType = "patch"
)

Write-Host "Starting deployment process..." -ForegroundColor Green

# Check if Node.js is installed
try {
    $nodeVersion = node --version
    Write-Host "Node.js version: $nodeVersion" -ForegroundColor Yellow
} catch {
    Write-Host "Node.js is not installed. Please install Node.js first." -ForegroundColor Red
    exit 1
}

# Install dependencies if node_modules doesn't exist
if (-not (Test-Path "node_modules")) {
    Write-Host "Installing dependencies..." -ForegroundColor Yellow
    npm install
}

# Bump version
Write-Host "Bumping version ($VersionType)..." -ForegroundColor Yellow
npm version $VersionType --no-git-tag-version

# Get the new version
$packageJson = Get-Content "package.json" | ConvertFrom-Json
$version = $packageJson.version
$buildNumber = [DateTime]::Now.ToString("yyyyMMddHHmmss")
$fullVersion = "$version.$buildNumber"

Write-Host "Building version: $fullVersion" -ForegroundColor Cyan

# Set environment variable for build script
$env:BUILD_NUMBER = $buildNumber

# Run build script
npm run build

Write-Host "Build completed successfully!" -ForegroundColor Green
Write-Host "Version: $fullVersion" -ForegroundColor Cyan

# Optional: Commit changes
$commit = Read-Host "Do you want to commit and push changes? (y/n)"
if ($commit -eq "y" -or $commit -eq "Y") {
    git add .
    git commit -m "Bump version to $version and update build number to $buildNumber"
    git push
    Write-Host "Changes committed and pushed!" -ForegroundColor Green
}

Write-Host "Deployment completed!" -ForegroundColor Green
