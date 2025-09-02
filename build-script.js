const fs = require('fs');
const path = require('path');

// Get version from package.json
const packageJson = JSON.parse(fs.readFileSync('package.json', 'utf8'));
const version = packageJson.version;

// Get build number from environment variable or use timestamp
const buildNumber = process.env.BUILD_NUMBER || Date.now();
const fullVersion = `${version}.${buildNumber}`;

console.log(`Building version: ${fullVersion}`);

// Read index.html
const indexPath = path.join(__dirname, 'web', 'index.html');
let content = fs.readFileSync(indexPath, 'utf8');

// Replace version in index.html
const versionRegex = /document\.getElementById\('version'\)\.textContent = "ver\.\d+\.\d+\.\d+.*?";/;
const newVersionLine = `document.getElementById('version').textContent = "ver.${fullVersion}";`;

if (versionRegex.test(content)) {
  content = content.replace(versionRegex, newVersionLine);
  console.log('Version updated in index.html');
} else {
  console.log('Version line not found, adding new version line');
  // If the pattern doesn't exist, add it before the closing script tag
  content = content.replace('</script>', `        document.getElementById('version').textContent = "ver.${fullVersion}";\n    </script>`);
}

// Write back to file
fs.writeFileSync(indexPath, content, 'utf8');

console.log(`Build completed successfully with version: ${fullVersion}`);
