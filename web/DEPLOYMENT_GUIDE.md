# Azure Static Website Deployment Guide

## HTML File Cache Management

### Problem
Browsers cache the `index.html` file, so users don't see updates immediately after deployment.

### Solutions

#### 1. Azure Static Web Apps Configuration (Recommended)
- Use `staticwebapp.config.json` to set cache headers
- Forces browsers to always fetch the latest HTML

#### 2. HTML Meta Tags (Backup)
- Added cache-control meta tags to HTML head
- Provides additional cache prevention

#### 3. Manual Cache Clearing
- **Chrome**: Ctrl+Shift+R (hard refresh)
- **Firefox**: Ctrl+F5
- **Edge**: Ctrl+Shift+R

## Cache Management Strategies

### 1. Version-Based Cache Busting (Implemented)
- Update `version.txt` file before each deployment
- All assets automatically get version parameters (`?v=1.1.0`)
- Browsers will fetch new versions when version changes

### 2. Azure CDN Cache Purging
If using Azure CDN:
```bash
# Using Azure CLI
az cdn endpoint purge --resource-group <resource-group> --name <cdn-endpoint> --profile-name <cdn-profile> --content-paths "/*"
```

### 3. Cache-Control Headers
Add to your deployment script or Azure configuration:

```json
{
  "staticContent": {
    "clientCache": {
      "cacheControlMode": "UseMaxAge",
      "cacheControlMaxAge": "00:05:00"
    }
  }
}
```

### 4. Deployment Workflow
1. **Update version.txt** - Increment version number
2. **Deploy to Azure** - Upload all files
3. **Purge CDN** (if using CDN) - Clear cache
4. **Test** - Verify new version loads

### 5. Manual Cache Clearing
For immediate testing:
- **Chrome**: Ctrl+Shift+R (hard refresh)
- **Firefox**: Ctrl+F5
- **Edge**: Ctrl+Shift+R

### 6. Azure Static Web Apps Configuration
If using Azure Static Web Apps, add to `staticwebapp.config.json`:

```json
{
  "globalHeaders": {
    "Cache-Control": "public, max-age=300"
  },
  "routes": [
    {
      "route": "/version.txt",
      "headers": {
        "Cache-Control": "no-cache, no-store, must-revalidate"
      }
    }
  ]
}
```

## Best Practices

1. **Always update version.txt** before deployment
2. **Use semantic versioning** (1.1.0, 1.1.1, etc.)
3. **Test in incognito mode** after deployment
4. **Monitor CDN cache** if using Azure CDN
5. **Set appropriate cache headers** for different file types

## Quick Deployment Checklist

- [ ] Update `version.txt`
- [ ] Test locally
- [ ] Deploy to Azure
- [ ] Purge CDN (if applicable)
- [ ] Test in browser (incognito mode)
- [ ] Verify version number displays correctly
