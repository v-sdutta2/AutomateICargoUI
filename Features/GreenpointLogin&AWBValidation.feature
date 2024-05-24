﻿Feature: GreenpointLogin&AWBValidation

A short summary of the feature

@tag1
Scenario: Greenpoint Login and AWB Validation
	Given User launches to Greenpoint Application
	When User enter valid username and password
	Then logs into the Greenpoint Application
	And User searches for flight "<FlightNumber>"
	And User selects the cargo gate of the flight
	And validates the manifested "<AWB>" number
	And User logs out of the Greenpoint application

	Examples: 
	| AWB        | FlightNumber |
	| 1234567890 | 61           |
