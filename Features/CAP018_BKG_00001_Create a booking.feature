Feature: CAP018_BKG_00001_iCargo Login and Create New Shipment


Scenario Outline: iCargo Login and Create New Shipment
	#Given User lauches the Url of iCargo Staging UI
	#Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	#When User clicks on the oidc button
	#Then A new window is opened
	#And User enters into the  iCargo 'Home' page successfully	
	Given User wants to execute the example "<Execute>"
	When User switches station if BaseStation other than "<Origin>"
	When User enters screen name as 'CAP018'
	Then User enters into the  iCargo 'Maintain Booking' page successfully
	And User clicks on New/List button
	And User enters shipment details with Origin "<Origin>", Destination "<Destination>", Product Code "<ProductCode>" and Agent code
	And User enters Shipper and Consignee details
	And User enters commodity details with Commodity "<Commodity>", Pieces "<Piece>", Weight "<Weight>"
	And User selects flight for "<ProductCode>"
	And User clicks on Save button
	#Then User logs out from the application
Examples:
	| Origin | Destination | ProductCode | Commodity | Piece | Weight | Execute |
	| ANC    | SEA         | PRIORITY    | 2199      | 8     | 360    | No      |
	| SEA    | LAX         | GENERAL     | NONSCR    | 13    | 775    | Yes     |
	| SAN    | JFK         | GOLDSTREAK  | NONSCR    | 2     | 55     | No      |