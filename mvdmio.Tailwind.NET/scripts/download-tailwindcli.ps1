param(
  [string] $version = ""
)

$response = gh release list -R tailwindlabs/tailwindcss
$releases = $response | ForEach-Object {
    $columns = $_.Trim() -split "\s+", 4
    [PSCustomObject]@{
        Title     = $columns[0]
        Type      = $columns[1]
        TagName   = $columns[2]
        Published = $columns[3]
    }
}

if($version -eq "") {
  # Download latest version
  $version = $releases[0].Title
}

Write-Host "Downloading: $version"

$selectedRelease = $releases | Where-Object { $_.Title -eq $version }

if($selectedRelease -eq $null){
  Write-Host "Could not find release '$version'"
  Write-Host "Available releases:"
  Write-Host $releases | Format-Table -AutoSize
  return
}

$basePath = Split-Path $MyInvocation.MyCommand.Path -Parent
gh release download -p "*" $version -D "$basePath/../lib/tools" -R tailwindlabs/tailwindcss --clobber
$discard = New-Item "$basePath/../lib/tools/$version" -Force