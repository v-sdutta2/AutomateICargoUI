Feature: CAP018_BKG_00005_Create a multi leg booking with flights that do not meet minimum connection time

@CAP018
Scenario Outline: Create a multi leg booking with flights that do not meet minimum connection time and system should display a warning message
	Given User wants to execute the example "<Execute>"
	When User switches station if BaseStation other than "<Origin>"
	When User enters screen name as 'CAP018'
	Then User enters into the  iCargo 'Maintain Booking' page successfully
	And User clicks on New/List button
	And User enters shipment details with Origin "<Origin>", Destination "<Destination>", Product Code "<ProductCode>" and Agent code
	And User enters Shipper and Consignee details
	And User enters commodity details with Commodity "<Commodity>", Pieces "<Piece>", Weight "<Weight>"
	And User searches for the multileg flight to verify RES bubble 'red' a warning message as 'Minimum Handling / Connection Time Fails' and product code as "<ProductCode>"	
Examples:
	| Origin | Destination | ProductCode | Commodity | Piece | Weight | Execute |
	| SEA    | BET         | PRIORITY    | 2199      | 4     | 120    | No      |
	| PDX    | BWI         | PRIORITY    | 0300      | 10    | 950    | Yes     |
