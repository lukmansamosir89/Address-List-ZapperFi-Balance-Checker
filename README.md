# ZapperFi-Balance-Checker
Batch Address List Balance Checker Using Of ZapperFi
Embedded with Tor Proxy And CefSharp Browser

![BalanceCheckerGif](https://raw.githubusercontent.com/tractorAside/ZapperFi-Balance-Checker/main/ZapperFi.gif)

How To Use:

Please provide at least one text file (e.g., addresses1.txt). If you have long lists, divide them into 2, 3, or 4 files (e.g., addresses1.txt, addresses2.txt, addresses3.txt, addresses4.txt).

'''
For a well-configured Seed/Address List:
Address Checker:
The line must start or contain "Address:," and the address must come after that part.

Seed Checker:
The line must start or contain "Seed:," and the seed phrase must come after that part.
The Balance Checker will attempt the first three addresses of the seed, regardless of the balance. If the third balance is greater than 0, it will try the fourth; if the fourth balance is greater than 0, it will try the fifth. This process continues until the balance equals 0.

If there is anything different in the line, the balance checker will continue with the next row.
'''

Use the following buttons to initiate searches:
Top Left Button: Start search with addresses1 list.
Top Bottom Button: Start search with addresses2 list.
Right Top Button: Start search with addresses3 list.
Right Bottom Button: Start search with addresses4 list.
Press any button and wait for the CloudFlare check. After clicking the CloudFlare checkbox, press the button again. The balance checker loop will begin.



Note: Best used with my "Private Key and Seed Excavator," this tool can identify seed phrases and private keys even in spaghetti text.
Note: The Balance Checker does not work with private keys. Use my "Private Key and Seed Excavator" to convert private keys to public addresses.

#Zapper #ZapperFi #ZapperXYZ #Batch-Balance-Checker #Balance-Checker #Address-List-Balance-Checker
