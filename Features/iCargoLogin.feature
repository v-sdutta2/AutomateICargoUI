Feature: iCargoLogin
	

@iCargoLogin
Scenario: Validate iCargo login with valid credentials
	Given User lauches the Url of iCargo Staging UI
	Then User enters into the  iCargo 'Sign in to icargoas' page successfully
	When User clicks on the oidc button
	Then A new window is opened
	And User enters into the  iCargo 'Home' page successfully
	Then User logs out from the application
	
   
	
