"Web Crawler definitions"

Object agent: #Downloader!

!Downloader methods!

download: aUrl
	| webclient content |
	webclient := @System.Net.WebClient new.
	content := webclient downloadString: aUrl.
	@System.Console out writeLine: content
! !
