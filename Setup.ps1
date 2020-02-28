$ErrorActionPreference = "Stop"
Clear-Host
try {
    Write-Host "COMPILE" -ForegroundColor Magenta
    Write-Host "-------------------------------------------------------------------------" -ForegroundColor Magenta
	Write-Host "1.1 - Begin to complie" -ForegroundColor Magenta
    $compiler = "$env:windir/Microsoft.NET/Framework/v3.5/csc"  
    &$compiler /target:exe passgen.cs  
    Write-Host "1.2 - Compliation complete" -ForegroundColor Magenta
    Write-Host "-------------------------------------------------------------------------" -ForegroundColor Magenta
} catch {
    Write-Host ""
    Write-Host "-------------------------------------------------------------------------" -ForegroundColor Red
	Write-Host "ERROR: Failed compile file." -ForegroundColor Red
	Write-Host $error[0]
    Write-Host "-------------------------------------------------------------------------" -ForegroundColor Red
	Exit 1
}

try {
    Write-Host ""
    Write-Host "COPY" -ForegroundColor Yellow
    Write-Host "-------------------------------------------------------------------------"  -ForegroundColor Yellow
	Write-Host "2.1 - Try to copy guid.exe to system32" -ForegroundColor Yellow
    Copy-Item "passgen.exe" -Destination "$env:windir/System32/"
    Write-Host "2.2 - Copy completed, enjoy guid in the Windows Console." -ForegroundColor Yellow
    Write-Host "-------------------------------------------------------------------------"  -ForegroundColor Yellow
} catch {
    Write-Host ""
    Write-Host "-------------------------------------------------------------------------" -ForegroundColor Red
	Write-Host "ERROR: Failed copy file." -ForegroundColor Red
	Write-Host $error[0] -ForegroundColor Red
    Write-Host "-------------------------------------------------------------------------" -ForegroundColor Red
	Exit 1
}
