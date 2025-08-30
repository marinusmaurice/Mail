# Email Sync Setup Guide

## Overview
The email synchronization functionality now works with real email providers including Gmail, Yahoo, and other IMAP/SMTP servers. Here's how to set it up and troubleshoot sync issues.

## Setting Up Email Accounts

### 1. Quick Setup (Recommended)
- Launch the application
- Click "Yes" when prompted to set up an account
- Enter your email address and password
- The system will auto-detect your provider (Gmail, Yahoo, etc.)
- Click "Set Up" to test the connection

### 2. Manual Setup (Advanced)
- Go to File ? Settings ? Add Account
- Choose "Advanced" for custom settings
- Configure server settings manually

## Supported Email Providers

### Gmail
- **Incoming (IMAP)**: imap.gmail.com, Port 993, SSL
- **Outgoing (SMTP)**: smtp.gmail.com, Port 587, STARTTLS
- **Note**: Use App Password instead of your regular password

### Yahoo Mail
- **Incoming (IMAP)**: imap.mail.yahoo.com, Port 993, SSL
- **Outgoing (SMTP)**: smtp.mail.yahoo.com, Port 587, STARTTLS
- **Note**: Enable "Less secure app access" or use App Password

### Outlook.com/Hotmail
- **Type**: Select "Outlook" for automatic configuration
- **Note**: Uses OAuth2 authentication (secure)

### Corporate Exchange
- **Type**: Select "Exchange" 
- **Server**: Your organization's server (e.g., mail.company.com)

## Sync Features

### Automatic Sync
- Syncs on startup (if accounts are configured)
- Background sync every time you start the app
- Fetches up to 50 recent emails per folder

### Manual Sync
- **Tools ? Send/Receive All** - Full synchronization
- **F5** - Quick refresh (if shortcut is configured)

### What Gets Synced
- ? Inbox emails
- ? Sent items
- ? Drafts
- ? Email attachments (detected)
- ? Read/unread status
- ? Important flags

## Troubleshooting Sync Issues

### Common Problems

1. **"Connection failed" error**
   - Check internet connection
   - Verify server settings
   - Ensure firewall isn't blocking ports 993/587

2. **Gmail "Authentication failed"**
   - Enable 2-factor authentication
   - Generate App Password: Google Account ? Security ? App Passwords
   - Use App Password instead of regular password

3. **Yahoo "Login failed"**
   - Enable App Passwords in Yahoo Account Security
   - Use generated App Password

4. **Outlook/Exchange issues**
   - For personal Outlook accounts, OAuth2 is required
   - For corporate Exchange, contact IT for server settings

5. **Some emails not appearing**
   - Check if emails are in different folders
   - System fetches most recent 50 emails only
   - Some emails might be filtered out

### Status Messages
Watch the status bar for sync progress:
- "Connecting to server..." - Establishing connection
- "Fetching emails..." - Downloading messages
- "Processing X emails..." - Adding to local storage
- "Sync complete: X new emails" - Success!

### Error Messages
- "Failed to receive emails" - Connection or authentication issue
- "Retry X/3" - Temporary network issue, will retry
- "Background sync failed" - Check account settings

## Performance Tips

1. **Reduce email count**: System fetches 50 recent emails by default
2. **Stable internet**: Ensure reliable connection during sync
3. **Account limits**: Some providers limit concurrent connections
4. **Server load**: Sync may be slower during peak hours

## Security Notes

- ? App Passwords are recommended over regular passwords
- ? SSL/TLS encryption is used for all connections
- ? Passwords are stored securely in memory only
- ?? For corporate accounts, follow your organization's security policies

## Getting Help

If sync still doesn't work:
1. Check the Output window for detailed error messages
2. Verify account settings in File ? Settings
3. Test connection using the "Test Connection" button
4. Try setting up the account manually with advanced settings

Remember: The first sync may take longer as it downloads recent emails. Subsequent syncs will be faster as only new emails are fetched.