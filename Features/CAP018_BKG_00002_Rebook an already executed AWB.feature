Feature: CAP018_BKG_00002_Rebook an already executed AWB

@CAP018
Scenario Outline: iCargo Login and Rebook an already executed AWB
	Given User lauches the Url of iCargo Staging UI
	Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	When User clicks on the oidc button
	Then A new window is opened
	And User enters into the  iCargo 'Home' page successfully
	When User enters screen name as 'CAP018'
	Then User enters into the  iCargo 'Maintain Booking' page successfully
	And User enters the AWB number as "<AWB>"
	And User clicks on New/List button
	And User deletes the flight details and adds new flight details
	And User selects new carrier details
	And User clicks on Save button to save new flight details
	And User captures the irregularity details
	Then User logs out from the application

Examples:
	| AWB      |
	| 30078893 |
	