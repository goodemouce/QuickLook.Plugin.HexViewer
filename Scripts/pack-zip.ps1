$packet_dir = "..\packet\"
$packet_name = "QuickLook.Plugin.HexViewer"
$packet_zip = $packet_dir + $packet_name + ".zip"
$packet_file = $packet_dir + $packet_name + ".qlplugin"

# ɾ��֮ǰ���ļ�
Remove-Item $packet_file -ErrorAction SilentlyContinue

$files = Get-ChildItem -Path ..\bin\Release\ -Exclude *.pdb,*.xml

$packet_dir_exist = (Test-Path $packet_dir)

# ��������ļ���
if (-not $packet_dir_exist)
{
	$Null = New-Item -Path $packet_dir -ItemType "directory" 
}

# ���
Compress-Archive $files $packet_zip
Move-Item $packet_zip $packet_file