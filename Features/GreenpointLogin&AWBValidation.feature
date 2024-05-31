Feature: GreenpointLogin&AWBValidation

A short summary of the feature

@tag1
Scenario: Greenpoint Login and AWB Validation
	Given User launches to Greenpoint Application
	When User enter valid username and password
	Then logs into the Greenpoint Application
	And User searches for flight "<FlightNumber>" and clicks on the cargo gate
	And validates the manifested "<AWB>" number, "<Pieces>" and "<Weight>"
	And User logs out of the Greenpoint application

Examples:
	| AWB          | FlightNumber | Pieces | Weight |
	| 027-30077003 | 164          | 25     | 124    |
