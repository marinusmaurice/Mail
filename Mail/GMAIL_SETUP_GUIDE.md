# Gmail Setup Guide - Get Sync Working Now!

## ?? **Quick Gmail Setup (5 Minutes)**

This guide will get your Gmail account syncing real emails in 5 minutes.

## ? **Step 1: Create Gmail App Password (Required)**

Gmail requires an "App Password" instead of your regular password for security.

### Enable 2-Factor Authentication (if not already enabled):
1. Go to [myaccount.google.com](https://myaccount.google.com)
2. Click **Security** (left sidebar)
3. Under "Signing in to Google", click **2-Step Verification**
4. Follow the setup if not already enabled

### Generate App Password:
1. Go to [myaccount.google.com/security](https://myaccount.google.com/security)
2. Under "Signing in to Google", click **App passwords**
3. Select app: **Mail**
4. Select device: **Windows Computer** (or Other)
5. Click **Generate**
6. **Copy the 16-character password** (like `abcd efgh ijkl mnop`)

## ?? **Step 2: Set Up Gmail in Your Email Client**

1. **Launch the email application**
2. When prompted "set up an email account", click **Yes**
3. **Enter your details**:
   - **Email**: `your.email@gmail.com`
   - **Display Name**: `Your Name`
   - **Password**: **Paste the app password** (not your regular Gmail password!)
4. Click **Set Up**

The app will automatically detect Gmail and configure:
- **IMAP**: `imap.gmail.com:993` (SSL)
- **SMTP**: `smtp.gmail.com:587` (STARTTLS)

## ?? **Step 3: Verify Sync**

1. **Watch the status bar** for messages like:
   - "Connecting to imap.gmail.com..."
   - "Fetching emails from Inbox..."
   - "Processing X emails..."
   - "Sync complete: X new emails added"

2. **Check your emails appear** in the inbox

3. **Manual sync**: Click **Tools ? Send/Receive All** to sync manually

## ?? **Step 4: Test with Real Email**

1. **Send yourself a test email** from another account
2. **Click Send/Receive All** in the app
3. **Verify the new email appears** in your inbox

## ?? **Common Issues & Solutions**

### "Authentication Failed"
- ? **Use App Password**: Don't use your regular Gmail password
- ? **Enable 2FA**: App passwords require 2-factor authentication
- ? **Copy correctly**: App password is 16 characters with spaces

### "Connection Failed"  
- ? **Check internet**: Ensure stable connection
- ? **Firewall**: Make sure ports 993 and 587 aren't blocked
- ? **Corporate network**: Some companies block IMAP/SMTP

### "Some emails missing"
- ? **Recent emails only**: App fetches last 20 emails for performance
- ? **Check folders**: Look in Sent, Drafts folders
- ? **Gmail labels**: Some emails might be in labeled folders

## ?? **Debug Information**

### Visual Studio Debug Output:
Look for these messages in the Output window:
```
Connecting to imap.gmail.com:993 with SSL=True
Opening folder: INBOX
Folder INBOX contains 156 messages
Fetching messages from 136 to 155
Fetched email: Your Real Email Subject
Successfully fetched 20 emails from Inbox
```

### Status Bar Messages:
- ? "Ready" = Sync completed successfully
- ?? "Sync failed" = Check credentials/connection
- ?? "Connecting..." = In progress

## ?? **Expected Results**

After successful setup, you should see:
- ? **Real Gmail emails** in your inbox
- ? **Actual subjects and senders** from your Gmail account
- ? **Recent 20 emails** downloaded for performance
- ? **Background sync** when app starts
- ? **Manual sync** works with Send/Receive All

## ?? **You're Done!**

Once you see your real Gmail emails in the inbox, the sync is working! The app will now:
- ? Download your actual emails from Gmail servers
- ? Show real email content, not fake data
- ? Sync automatically on startup
- ? Allow manual sync anytime

## ?? **Still Having Issues?**

1. **Double-check app password** is correct (16 characters)
2. **Try manual setup** with File ? Settings ? Add Account
3. **Check debug output** in Visual Studio
4. **Test connection** using the Test Connection button

**The sync now uses real IMAP connections to Gmail servers - no more fake emails!**