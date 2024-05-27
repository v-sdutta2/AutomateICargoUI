Feature: CAP018_BKG_00004_Create a booking given an AWB from stock

@Cap018
Scenario Outline: Create a booking given an AWB from stock and system will create a new awb
	Given User lauches the Url of iCargo Staging UI
	Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	When User clicks on the oidc button
	Then A new window is opened
	And User enters into the  iCargo 'Home' page successfully
	When User enters screen name as 'CAP018'
	Then User enters into the  iCargo 'Maintain Booking' page successfully
	And User enters the AWB number as "<AWB>"
	And User clicks on New/List button
	And a banner appears for the awb does not exist	
	And User enters unknown shipment details with Origin "<Origin>", Destination "<Destination>", Product Code "<ProductCode>" and Agent code
	And User enters Unknown Shipper "<Shipper>" and Consignee "<Consignee>" details 
	And User enters commodity details with Commodity "<Commodity>", Pieces "<Piece>", Weight "<Weight>"	
	And User selects flight for "<ProductCode>"
	And User clicks on Save button
	Then User logs out from the application
Examples:
	| AWB      | Origin | Destination |  ProductCode | Commodity | Piece | Weight | AgentCode | Shipper | Consignee |
	| 74426004 | ANC    | ANC         |  GENERAL     | 0316      | 2     | 20     |  82165     |82165    | 82165    |
