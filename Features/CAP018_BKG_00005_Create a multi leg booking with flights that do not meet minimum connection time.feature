Feature: CAP018_BKG_00005_Create a multi leg booking with flights that do not meet minimum connection time


Scenario: Create a multi leg booking with flights that do not meet minimum connection time and system should display a warning message
	Given User lauches the Url of iCargo Staging UI
	Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	When User clicks on the oidc button
	Then A new window is opened
	And User enters into the  iCargo 'Home' page successfully
	When User enters screen name as 'CAP018'
	Then User enters into the  iCargo 'Maintain Booking' page successfully
	And User clicks on New/List button
	And User enters shipment details with Origin "<Origin>", Destination "<Destination>", Product Code "<ProductCode>"
	And User enters Shipper and Consignee details
	And User enters commodity details with Commodity "<Commodity>", Pieces "<Piece>", Weight "<Weight>"
	And User searches for the multileg flight to verify RES bubble 'red' a warning message as 'Minimum Handling / Connection Time Fails' and product code as "<ProductCode>"
	#And User clicks on select flight to search for the given Flight No "<FlightNo>"
	#And User gets RES bubble 'red' a warning message as 'Minimum Handling / Connection Time Fails'
	Then User logs out from the application
Examples:
	| Origin | Destination | ShippingDate | ProductCode | Commodity | Piece | Weight | FlightDate  | FlightNo |
	| ANC    | LAX         | 24-Apr-2024  | PRIORITY     | 0091      | 2     | 50    | 24-Apr-2024 | 108 1246 |
