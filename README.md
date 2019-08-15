# crispy-enigma
A McDonald's shift parser from email that creates a schedule in your outlook calendar.

This project started the day I was too lazy to receive my mail and create each shift by hand on my outlook calendar, so I created that tool that automated the process for me! Look at this [mail sample](SampleMail.txt) to have an idea of the email I used to receive everyday for 4 years!

## Setup
First, run the tool using the Script on command line. Then, just launch the command `start` on the shell to deploy the server environment. Now wait for a new mail to come in your inbox folder and if it's coming from mcdo, it will parse that and create automatically your calendar shift.


## Limitations
There is altough some limitations:
 - Your email given to your manager must be of outlook type.
 - It must be ran on a Windows PC that has an outlook application setup.
 - The calendar name is hardcoded to 'familial' it's something I wish to put in a setup place.
 - Instead of looking for a specific type of object, it would be better to actually verify if that email came from Mc Donald's CANADA.
 - This is tested only with one way of handing out schedule other MC Donald's then Lachenaie may use a different system.

