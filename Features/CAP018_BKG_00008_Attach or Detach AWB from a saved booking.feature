Feature: CAP018_BKG_00008_Attach or Detach AWB from a saved booking



Scenario Outline: Attach and Detach AWB from a saved booking to generate new AWB number
	Given User lauches the Url of iCargo Staging UI
	Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	When User clicks on the oidc button
	Then A new window is opened
	And User enters into the  iCargo 'Home' page successfully
	When User enters screen name as 'CAP018'
	Then User enters into the  iCargo 'Maintain Booking' page successfully
	And User enters the AWB number as "<AWB>"
	And User clicks on New/List button
	And User clicks on Attach/Detach button
	And User enters new Agent Code "<AgentCode>"
	And User clicks on Save button
	Then User logs out from the application

Examples:
	| AWB      | AgentCode  | 
	| 30074542 | ASQXGUEST  | 

	#30073470  31375024