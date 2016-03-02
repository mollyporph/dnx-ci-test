$PSScriptFilePath = (Get-Item $MyInvocation.MyCommand.Path).FullName

" PSScriptFilePath = $PSScriptFilePath"

$SolutionRoot = Split-Path -Path $PSScriptFilePath -Parent
$TestsFolder = Join-Path -Path $SolutionRoot -ChildPath "src/appveyor.test";

$DNU = "dnu"
$DNX = "dnx"
$DNVM = "dnvm"

# ensure the correct version
& $DNVM install 1.0.0-rc1-update1 -r mono

# use the correct version
& $DNVM use 1.0.0-rc1-update1 -r mono

& $DNU restore "$TestsFolder"
if (-not $?)
{
	throw "The DNU restore process returned an error code."
}

& $DNU build "$TestsFolder"
if (-not $?)
{
	throw "The DNU build process returned an error code."
}

# run them
& $DNX -p "$TestsFolder" test
if (-not $?)
{
	throw "The DNX test process returned an error code."
}