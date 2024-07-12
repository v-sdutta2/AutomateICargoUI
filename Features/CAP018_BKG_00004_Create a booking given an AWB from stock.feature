Feature: CAP018_BKG_00004_Create a booking given an AWB from stock

@CAP018 @CAP018_BKG_00004
Scenario Outline: Create a booking given an AWB from stock and system will create a new awb
	Given User wants to execute the example "<Execute>"
	When User switches station if BaseStation other than "<Origin>"
	When User enters screen name as 'CAP018'
	Then User enters into the  iCargo 'Maintain Booking' page successfully
	And User enters the AWB number as "<AWB>"
	And User clicks on New/List button
	And a banner appears for the awb does not exist
	And User enters shipment details with Origin "<Origin>", Destination "<Destination>", Product Code "<ProductCode>" and Agent code
	And User enters Unknown Shipper "<Shipper>" and Consignee "<Consignee>" details
	And User enters commodity details with Commodity "<Commodity>", Pieces "<Piece>", Weight "<Weight>"
	And User selects flight for "<ProductCode>"
	And User clicks on Save button
Examples:
	| AWB      | Origin | Destination | ProductCode | Commodity | Piece | Weight | Shipper | Consignee | Execute |
	| 74428362 | ANC    | FAI         | GENERAL     | 0316      | 2     | 20     | 82165   | 82165     | Yes     |
