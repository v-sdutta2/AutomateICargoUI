Feature: CAP018_BKG_00007_Create a booking for an AVI

@tag1
 Scenario Outline: iCargo Login and Create New AVI Shipment
        Given User lauches the Url of iCargo Staging UI
	    Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	    When User clicks on the oidc button
	    Then A new window is opened
        And User enters into the  iCargo 'Home' page successfully
        When User enters screen name as 'CAP018'
        Then User enters into the  iCargo 'Maintain Booking' page successfully
        And User clicks on New/List button
        And User enters shipment details with Origin "<Origin>", Destination "<Destination>", Product Code "<ProductCode>"
        And User enters Shipper and Consignee details
        And User enters commodity details with Commodity "<Commodity>", Pieces "<Piece>", Weight "<Weight>"
        And User selects flight for "<ProductCode>"
       # And User enters Carrier details with Origin "<Origin>", Destination "<Destination>", Flight No "<FlightNo>", Flight Date "<FlightDate>", Pieces "<Piece>", Weight "<Weight>"   
        And User clicks on Save button and fills the checksheet details to generate awb
        Then User logs out from the application
        Examples:
            | Origin | Destination | ShippingDate | ProductCode | Commodity | Piece | Weight | 
            | SEA    | ANC         | 24-Apr-2024  | PET CONNECT | 9730      | 2     | 50     | 
	
