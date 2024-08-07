﻿Feature: LTE001_ACC_00001_Create a PP AWB in LTE001 for a known shipper
 
Create a New Shipment, Acceptance of that new shipment & screening as a CGO or CGODG user
 
@LTE001
Scenario Outline: Create a PP AWB in LTE001 for a known shipper
	#Given User lauches the Url of iCargo Staging UI
	#Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	#When User clicks on the oidc button
	#Then A new window is opened
	#And User enters into the  iCargo 'Home' page successfully
	Given User wants to execute the example "<Execute>"
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
	And User enters the Screening details for row 1 with screeingMethod as 'Transfer Manifest Verified' and ScreeningResult as 'Pass'
	And User clicks on the ContinueScreeningDetails button
	And User fills up the checksheet for ProductCode "<ProductCode>" if applicable
	And User checks the AWB_Verified checkbox
	And User saves all the details & handles all the popups
	And User closes the LTE screen
	Then User logs out from the application
 
Examples:
	| AgentCode | ShipperCode | ConsigneeCode | Origin | Destination | ProductCode | SCC  | Commodity | ShipmentDescription | ServiceCargoClass | Piece | Weight | ChargeType | ModeOfPayment | cartType | Execute |
	| 10763     | 10763       | 10763         | SEA    | LAX         | GENERAL     | None | NONSCR    | None                | None              | 13    | 775    | PP         | CREDIT        | CART     | Yes     |
	| 10763     | 10763       | 10763         | ANC    | HNL         | PRIORITY    | None | 2199      | None                | None              | 8     | 360    | PP         | CREDIT        | CART     | No      |
	| 10763     | 10763       | 10763         | SAN    | JFK         | GOLDSTREAK  | None | NONSCR    | None                | None              | 2     | 55     | PP         | CREDIT        | CART     | No      |