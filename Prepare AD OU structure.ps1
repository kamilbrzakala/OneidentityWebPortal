New-ADOrganizationalUnit -Name "CEO" -Path "DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Users" -Path "OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Groups" -Path "OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False

New-ADOrganizationalUnit -Name "Audit" -Path "OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Users" -Path "OU=Audit,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Groups" -Path "OU=Audit,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False

New-ADOrganizationalUnit -Name "Finance" -Path "OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Users" -Path "OU=Finance,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Groups" -Path "OU=Finance,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False

New-ADOrganizationalUnit -Name "Marketing" -Path "OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Users" -Path "OU=Marketing,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Groups" -Path "OU=Marketing,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False

New-ADOrganizationalUnit -Name "HR" -Path "OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Users" -Path "OU=HR,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Groups" -Path "OU=HR,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False

New-ADOrganizationalUnit -Name "IT" -Path "OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Users" -Path "OU=IT,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Groups" -Path "OU=IT,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "IAM" -Path "OU=IT,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Users" -Path "OU=IAM,OU=IT,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Groups" -Path "OU=IAM,OU=IT,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "SOC" -Path "OU=IT,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Users" -Path "OU=SOC,OU=IT,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False
New-ADOrganizationalUnit -Name "Groups" -Path "OU=SOC,OU=IT,OU=CEO,DC=ONEIDENTITY,DC=LAB" -ProtectedFromAccidentalDeletion $False 
