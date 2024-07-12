Feature: OPR344_EXP_00002_Manifest an AWB from the lying list

Manifest a Shipment as a CGO or CGODG user

@OPR344
Scenario Outline: Manifest an AWB from the lying list
	Given User lauches the Url of iCargo Staging UI
	Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	When User clicks on the oidc button
	Then A new window is opened
	And User enters into the  iCargo 'Home' page successfully
	When User switches station if BaseStation other than "<Origin>"
	When User enters the screen name as 'OPR344'
	Then User enters into the  iCargo 'Export Manifest' page successfully
	When User enters the Booked FlightNumber with "<FlightNumber>"
	And User enters Booked ShipmentDate
	And User clicks on the List button to fetch the Booked Shipment
	And User creates new ULD/Cart in Assigned Shipment with cartType "<cartType>" and pou "<Destination>"
	And User filterouts the Booked AWB from '<AWBSectionName>' and Created ULD_Cart
	And User validates the warning message "The shipment is not booked to the flight"
	And User clicks on the Manifest button
	And User closes the PrintPDF window
	And User validates the AWB is "Manifested" in the Export Manifest screen
	Then User closes the Export Manifest screen
	Then User logs out from the application

Examples:
	| Origin | Destination | FlightNumber | Piece | Weight | cartType | AWBSectionName |
	| SEA    | ANC         | 93           | 2     | 59     | CART     | LyingList      |
