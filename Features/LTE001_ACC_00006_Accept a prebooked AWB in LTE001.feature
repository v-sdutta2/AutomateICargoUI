Feature: LTE001_ACC_00006_Accept a prebooked AWB in LTE001

Create a New Shipment, Acceptance of that new shipment & screening as a CGO or CGODG user

@tag1
Scenario Outline: Accept a prebooked AWB in LTE001
	Given User lauches the Url of iCargo Staging UI
	Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	When User clicks on the oidc button
	Then A new window is opened
	And User enters into the  iCargo 'Home' page successfully
	When User switches station if BaseStation other than "<Origin>"
	And User enters the screen name as 'LTE001'
	Then User enters into the  iCargo 'Create Shipment' page successfully
	When User enters an AWB "<prebookedAWB>" of a PreBooked Shipment
	And User opens & verifies the Participant Details
	And User clicks on the ContinueParticipant button
	And User enters the Certificate details
	And User clicks on the ContinueCertificate button
	And User opens & verifies the Shipment Details
	And User clicks on the ContinueShipment button
	And User opens & verifies the Flight Details
	And User clicks on the ContinueFlightDetails button
	And user opens the Charge Details
	And User enters the Charge details with ChargeType "<ChargeType>" and ModeOfPayment "<ModeOfPayment>"
	And User clicks on the CalculateCharges button
	And User clicks on the ContinueChargeDetails button
	And User enters the Acceptance details with PreBooked pieces
	And User clicks on the ContinueAcceptanceDetails button
	And User enters the Screening details for row 1 with screeingMethod as 'Transfer Manifest Verified' and ScreeningResult as 'Pass'
	And User clicks on the ContinueScreeningDetails button
	And User checks the AWB_Verified checkbox
	And User clicks on the save button & handle Payment Portal
	And User saves all the details & handles all the popups
	And User closes the LTE screen
	Then User logs out from the application

Examples:
	| prebookedAWB | Origin | ChargeType | ModeOfPayment | cartType |
	| 027-30073223 | SEA    | PP         | CREDIT        | CART     |
