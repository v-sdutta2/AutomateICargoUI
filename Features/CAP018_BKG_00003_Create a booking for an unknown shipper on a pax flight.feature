Feature: CAP018_BKG_00003_Create a booking for an unknown shipper on a pax flight

A short summary of the feature

@tag1
Scenario: Create a booking for an unknown shipper on a pax flight
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
	And User enters shipment details with Origin "<Origin>", Destination "<Destination>",Agent Code "<AgentCode>", Product Code "<ProductCode>"
	And User enters Unknown Shipper "<Shipper>" and Consignee "<Consignee>" with all details
	And User enters commodity details with Commodity "<Commodity>", Pieces "<Piece>", Weight "<Weight>"
	And User selects flight for "<ProductCode>"
	And User clicks on Save button
	#Then User logs out from the application
Examples:
	| Origin | Destination | ProductCode | Commodity | Piece | Weight | AgentCode | Shipper | Consignee | Execute |
	| SEA    | LAX         | GENERAL     | NONSCR    | 13    | 775    | ASQXGUEST | C1001   | C1001     | Yes     |
	| ANC    | HNL         | PRIORITY    | 2199      | 8     | 360    | ASQXGUEST | C1001   | C1001     | No      |
	| SAN    | JFK         | GOLDSTREAK  | NONSCR    | 2     | 55     | ASQXGUEST | C1001   | C1001     | Yes     |