# Deployment Guide for Problem Jasia Retro

This project includes automatic version numbering and deployment capabilities.

## Files Created

- `package.json` - Node.js package configuration with build scripts
- `build-script.js` - Script that updates version numbers in HTML files
- `.github/workflows/deploy.yml` - Simple GitHub Actions workflow
- `.github/workflows/version-and-deploy.yml` - Advanced workflow with automatic version bumping
- `deploy.ps1` - PowerShell script for local deployment
- `DEPLOYMENT.md` - This documentation

## How It Works

### Version Numbering
- Base version is stored in `package.json` (currently 1.0.0)
- Build number is automatically generated (GitHub run number or timestamp)
- Final version format: `1.0.0.123` (version.buildNumber)

### Automatic Updates
The build script automatically updates the version in `web/index.html`:
```javascript
// Before
document.getElementById('version').textContent = "ver.1.0.0";

// After build
document.getElementById('version').textContent = "ver.1.0.0.123";
```

## Deployment Options

### Option 1: GitHub Actions (Recommended)

#### Simple Deployment
- Triggers on push to `main` or `webapp` branches
- Uses GitHub run number as build number
- Deploys to GitHub Pages
- Creates releases automatically

#### Advanced Deployment
- Manual trigger with version bump type selection
- Automatic version bumping (patch/minor/major)
- Creates Git tags and GitHub releases
- More sophisticated version management

### Option 2: Local Deployment

1. **Install Node.js** (if not already installed)
2. **Run the PowerShell script:**
   ```powershell
   .\deploy.ps1
   ```
3. **Or run manually:**
   ```bash
   npm install
   npm run build
   ```

### Option 3: Manual Version Bump

```bash
# Bump patch version (1.0.0 -> 1.0.1)
npm version patch

# Bump minor version (1.0.0 -> 1.1.0)
npm version minor

# Bump major version (1.0.0 -> 2.0.0)
npm version major

# Build with new version
npm run build
```

## GitHub Pages Setup

1. Go to your repository settings
2. Navigate to "Pages" section
3. Set source to "GitHub Actions"
4. The workflow will automatically deploy to GitHub Pages

## Custom Domain (Optional)

To use a custom domain, edit the workflow files and uncomment/update the `cname` parameter:
```yaml
cname: your-domain.com
```

## Environment Variables

The build script uses these environment variables:
- `BUILD_NUMBER` - Override the build number (defaults to timestamp or GitHub run number)

## Troubleshooting

### Build Script Issues
- Ensure Node.js is installed
- Check that `web/index.html` exists
- Verify the version line pattern matches the regex in `build-script.js`

### GitHub Actions Issues
- Ensure GitHub Pages is enabled in repository settings
- Check that the workflow has proper permissions
- Verify the branch names match your repository structure

### Local Deployment Issues
- Run `npm install` first
- Check PowerShell execution policy: `Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser`
- Ensure Git is configured properly for commits

## Version History

The system maintains version history through:
- Git tags (created automatically)
- GitHub releases (with changelog)
- Package.json version field
- Build artifacts with version numbers

## Next Steps

1. **Enable GitHub Pages** in your repository settings
2. **Test the workflow** by pushing to the main branch
3. **Customize the versioning** if needed (edit `build-script.js`)
4. **Add custom domain** if desired
5. **Monitor deployments** in the Actions tab
