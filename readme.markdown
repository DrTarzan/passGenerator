# GUIDGEN

## COMPILATION
* Open command prompt as administrator
	* Locate yourself to the same folder as pass.cs
	* Run the following command to complie to .exe:
		* %WINDIR%\Microsoft.NET\Framework\v3.5\csc.exe pass.cs 
* Then copy the file compiled, pass.exe, to:
	* %WINDIR%\System32\
	
## USAGE				
* Then you can generate new guides from the command prompt by:
use the following commands:

	* **pass**
		* Provides the following results:
		<pre>
			>pass

			New Password
			====================================
			Length: 8
			Password: _E_nFw12 (already copied to clipboard)
		</pre>
	* **pass /[lowerCaseCount] /[upperCaseCount] /[digitCount] /[StrangeCharsCount]** -> Where count is an integer
		* Provides the following results for example:
		<pre>
			>pass /2 /3 /4 /5

			New Password
			====================================
			Length: 14
			Password: Pf565#)P+?zR0@ (already copied to clipboard)
		</pre>
	* **pass -[lowerCaseCount] -[upperCaseCount] -[digitCount] -[StrangeCharsCount]** -> Where count is an integer
		* Provides the following results:
		<pre>
			>pass -2 -3 -4 -5

			New Password
			====================================
			Length: 14
			Password: Pf565#)P+?zR0@ (already copied to clipboard)
		</pre>
	* **guid ?**
		* Provides a list of all commands
	* **guid /?**
		* Provides a list of all commands
	* **guid -?**
		* Provides a list of all commands
	* **guid help**
		* Provides a list of all commands

