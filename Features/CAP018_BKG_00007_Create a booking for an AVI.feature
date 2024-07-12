Feature: CAP018_BKG_00007_Create a booking for an AVI

@CAP018
Scenario Outline: iCargo Login and Create New AVI Shipment
	Given User wants to execute the example "<Execute>"
	When User switches station if BaseStation other than "<Origin>"
	When User enters screen name as 'CAP018'
	Then User enters into the  iCargo 'Maintain Booking' page successfully
	And User clicks on New/List button
	And User enters shipment details with Origin "<Origin>", Destination "<Destination>", Product Code "<ProductCode>" and Agent code
	And User enters Shipper and Consignee details
	And User enters commodity details with Commodity "<Commodity>", Pieces "<Piece>", Weight "<Weight>"
	And User selects flight for "<ProductCode>"
	And User clicks on Save button and fills the checksheet details to generate awb
Examples:
	| Origin | Destination | ProductCode | Commodity | Piece | Weight | Execute |
	| ANC    | FAI         | PET CONNECT | 9730      | 2     | 50     | Yes     |
	
