Feature: LTE001_ACC_00015_Create an AWB for a CAO DG shipment and book on a pax flight

Create a New DG Shipment, Acceptance & screening of that as a CGODG user

@tag1
Scenario Outline: Create an AWB for a CAO DG shipment and book on a pax flight
	Given User lauches the Url of iCargo Staging UI
	Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	When User clicks on the oidc button
	Then A new window is opened
	And User enters into the  iCargo 'Home' page successfully
	When User switches station if BaseStation other than "<Origin>"
	And User enters the screen name as 'LTE001'
	Then User enters into the  iCargo 'Create Shipment' page successfully
	When user clicks on the List button
	And User enters the Participant details with AgentCode "<AgentCode>", ShipperCode "<ShipperCode>", ConsigneeCode "<ConsigneeCode>"
	And User clicks on the ContinueParticipant button
	And User enters the Certificate details
	And User clicks on the ContinueCertificate button
	And User enters the Shipment details with Origin "<Origin>", Destination "<Destination>", ProductCode "<ProductCode>", SCCCode "<SCC>", Commodity "<Commodity>", ShipmentDescription"<ShipmentDescription>", ServiceCargoClass "<ServiceCargoClass>", Piece "<Piece>", Weight "<Weight>"
	And User clicks on the ContinueShipment button
	And User clicks on the Select Flight Button
	And User selects an "Combination" flight
	And User clicks on the ContinueFlightDetails button
	And User enters the Charge details with ChargeType "<ChargeType>" and ModeOfPayment "<ModeOfPayment>"
	And User clicks on the CalculateCharges button
	And User clicks on the ContinueChargeDetails button
	And User enters the Acceptance details
	And User clicks on the ContinueAcceptanceDetails button
	And User enters the Screening details for row 1 with screeingMethod as 'ALT Dangerous Goods' and ScreeningResult as 'Pass'
	And User clicks on the ContinueScreeningDetails button
	And User enters details for CAO DG shipment with ChargeType "<ChargeType>",UNID "<UNID>", ProperShipmentName "<ProperShipmentName>", PackingInstruction "<PackingInstruction>",NoOfPkg "<Piece>", NetQtyPerPkg "<NetQtyPerPkg>", ReportableQnty "<ReportableQnty>"
	And User checks the AWB_Verified checkbox
	And User saves the CAO DG shipment with "Combination" flight	
	And User validates the popped up error message as "shipment can be booked only in Cargo / truck flight(s)"
	And User closes the LTE screen
	Then User logs out from the application

Examples:
	| AgentCode | ShipperCode | ConsigneeCode | Origin | Destination | ProductCode | SCC     | Commodity | ShipmentDescription | ServiceCargoClass | Piece | Weight | ChargeType | ModeOfPayment | cartType | UNID | ProperShipmentName    | PackingInstruction | NetQtyPerPkg | ReportableQnty |
	| 10763     | 10763       | 10763         | SEA    | ANC         | PRIORITY    | DGR,CAO | NONSCR    | UN3480              | None              | 1     | 30     | CC         | None          | CART     | 3480 | Lithium ion batteries | 965                | 0.5          | No             |

