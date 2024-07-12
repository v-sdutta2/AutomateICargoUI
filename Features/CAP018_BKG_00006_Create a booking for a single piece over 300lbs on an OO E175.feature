Feature: CAP018_BKG_00006_Create a booking for a single piece over 300lbs on an OO E175

@CAP018
Scenario Outline: Create a booking for a single piece over 300lbs on an OO E175 and system generates an AWB with a warning.
	Given User lauches the Url of iCargo Staging UI
	Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	When User clicks on the oidc button
	Then A new window is opened
	And User enters into the  iCargo 'Home' page successfully
	When User enters screen name as 'CAP018'
	Then User enters into the  iCargo 'Maintain Booking' page successfully
	And User clicks on New/List button
	And User enters shipment details with Origin "<Origin>", Destination "<Destination>", Product Code "<ProductCode>" and Agent code
	And User enters Shipper and Consignee details
	And User enters commodity details with Commodity "<Commodity>", Pieces "<Piece>", Weight "<Weight>"
	And User selects flight for "<ProductCode>"
	And User clicks on Save button
	And An an Embargo pops up with a warning message to generate new AWB
	Then User logs out from the application
Examples:
	| Origin | Destination | ProductCode | Commodity | Piece | Weight |
	| SEA    | ANC         | GENERAL     | 0316      | 2     | 310    |
