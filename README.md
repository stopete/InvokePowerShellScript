
# Remote PowerShell Script Executor (Windows Forms App)

This Windows Forms application is designed to streamline the execution of PowerShell scripts on remote Windows computers.  
It is particularly useful for system administrators and IT professionals who need to manage multiple machines across a network securely and efficiently.

---

## 🛠️ Built With

- Visual Studio 2022  
- C#  
- PowerShell  

---

## 📦 Requirements

- PowerShell 7  
- Visual Studio 2022  
- .NET Framework 4.8.1 Developer Pack (or greater)  
- .NET 7.0  

---

## 🖥️ Application UI

![App Screenshot](7643981f-757b-4ae2-8cd9-4beb7b703b55.png)

- The left panel allows selecting files from predefined folders (`Computers` and `Scripts`).
- The right panel becomes active if you enable the checkbox **"Option to browse files"**.
- After selecting both a computer list and a script, click the red arrow button to execute.
- Output is shown in the application console.

---

## 🚀 First-Time Setup

### 1. Configure Users

- Go to the application directory.
- Open `user.txt` and add users (e.g., `domain\adminuser`) who are authorized to run PowerShell scripts remotely.

### 2. Register Secret Vault

- Launch the app.
- Go to **Menu → Set up Vault**.
- Select a user from the dropdown (loaded from `user.txt`).
- Click **Go** to store the secret for that user.

> ✅ Example success message:  
> `Secret 'domain\adminuser' stored successfully in vault 'domain\adminuser'.`

> ℹ️ *By default, the secret and vault use the same name. You can change this by editing `setvault.ps1`.*

### 3. Update `InvokeScript.ps1`

- Open `InvokeScript.ps1` in Notepad.
- Modify the following line with the vault and secret name you used:
  
  ```powershell
  $cred = (Get-Secret -Vault domain\adminuser -Name domain\adminuser)
  ```
- Save and close the file.

---

## ▶️ Running a Script

You have **two options** to select scripts and target machines:

### Option A: Predefined Folders

- Save PowerShell scripts to the `Scripts` folder.
- Save computer lists (`.txt` files) to the `Computers` folder.

### Option B: Manual Selection

- Enable the checkbox **"Option to browse files"**.
- Use the file pickers to load your script and computer list manually.

### Execution

- After selecting a script and computer list, click the **Run** button.
- The script will execute on the listed remote computers.
- Output will appear in the app console.

---

## 📁 Folder Structure

```
📁 YourAppDirectory
├── Scripts         # Common PowerShell scripts
├── Computers       # Text files with target computer names
├── user.txt        # List of authorized users
├── setvault.ps1    # Vault creation script
├── InvokeScript.ps1
└── YourApp.exe
```

---

## 🔐 Security

Credentials are securely managed using the following PowerShell modules:

- `Microsoft.PowerShell.SecretManagement`
- `Microsoft.PowerShell.SecretStore`

---

## 📣 Notes

- Ensure `user.txt` is correctly populated before setting up the vault.
- Vault and secret names must match those referenced in `InvokeScript.ps1`.

---
