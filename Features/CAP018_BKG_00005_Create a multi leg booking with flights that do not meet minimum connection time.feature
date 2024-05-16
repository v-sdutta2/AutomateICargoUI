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
	And User enters shipment details with Origin "<Origin>", Destination "<Destination>", Product Code "<ProductCode>" and Agent code
	And User enters Shipper and Consignee details
	And User enters commodity details with Commodity "<Commodity>", Pieces "<Piece>", Weight "<Weight>"
	And User searches for the multileg flight to verify RES bubble 'red' a warning message as 'Minimum Handling / Connection Time Fails' and product code as "<ProductCode>"	
	Then User logs out from the application
Examples:
	| Origin | Destination |  ProductCode | Commodity | Piece | Weight | 
	| LAX    | FAI         |  PRIORITY     | 0091      | 2     | 50    | 
