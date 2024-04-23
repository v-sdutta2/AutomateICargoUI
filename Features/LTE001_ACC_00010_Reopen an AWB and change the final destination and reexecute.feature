Feature: LTE001_ACC_00010_Reopen an AWB and change the final destination and reexecute
Create a New Shipment, Acceptance of that new shipment & screening as a CGO or CGODG user

@tag1
Scenario Outline: Reopen an AWB and change the final destination and reexecute
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
	#And User enters the Flight details with CarrierCode "<CarrierCode>", FlightNo "<FlightNo>"
	And User clicks on the Select Flight Button
	And User selects an available flight
	And User clicks on the ContinueFlightDetails button
	And User enters the Charge details with ChargeType "<ChargeType>" and ModeOfPayment "<ModeOfPayment>"
	And User clicks on the CalculateCharges button
	And User clicks on the ContinueChargeDetails button
	And User enters the Acceptance details
	And User clicks on the ContinueAcceptanceDetails button
	And User enters the Screening details for row 1 with screeingMethod as 'Transfer Manifest Verified' and ScreeningResult as 'Pass'
	And User clicks on the ContinueScreeningDetails button
	And User checks the AWB_Verified checkbox
	And User clicks on the save button & handle Payment Portal
	And User saves all the details & handles all the popups
	When User enters the Executed AWB number
	And User Reopens the AWB
	And User verifies and Update the field 'destination' with updated value as 'PDX' in the Shipment Details	
	And User clicks on the ContinueShipment button
	And User verifies and Update the Flight Details with 'destination'
	And User clicks on the Select Flight Button
	And User selects an available flight
	And User clicks on the ContinueFlightDetails button
	And user opens the Charge Details
	And User clicks on the CalculateCharges button
	And User clicks on the ContinueChargeDetails button
	And User verifies and Update the Acceptance Details
	And User clicks on the ContinueAcceptanceDetails button
	And User verifies and Update the Screening Details
	And User clicks on the ContinueScreeningDetails button
	And User checks the AWB_Verified checkbox
	And User saves the details with capturing irregularity for flight destination change with ChargeType "<ChargeType>"
	And User validates the AWB is "EXECUTED"
	And User closes the LTE screen
	Then User logs out from the application


Examples:
	| AgentCode | ShipperCode | ConsigneeCode | Origin | Destination | ProductCode | SCC  | Commodity | ShipmentDescription | ServiceCargoClass | Piece | Weight | ChargeType | ModeOfPayment | cartType |
	| 10763     | 10763       | 10763         | SEA    | ANC         | GENERAL     | None | 0316      | None                | None              | 2     | 59     | CC         | None          | CART     |

	
