Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

@mytag
Scenario: Launch ORBITA Application
	Given I have ORBITA login page
	When I enter the credentials and click ok button
	Then I am on the default home page of ORBITA


