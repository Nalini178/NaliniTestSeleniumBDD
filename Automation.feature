Feature: Automation
	Automate basic transactions on a sample site

Scenario: Order a T-Shirt (and verify in order history)
	Given I am on the site http://automationpractice.com/
	And I login with my credentials
	When I click on the link T-Shirts
	And I hover over the first item and click on "Add to cart" and Proceed to checkout
	And I click on Proceed to checkout in the Summary phase
	#And I click on Proceed to checkout in the sign-in phase
	And I click on Proceed to checkout in the address phase
	And I select checkbox to agree terms in shipping phase
	And I click on Proceed to checkout in the shipping phase
	And I click on Pay by bank wire in the payment phase
	And I click on I confirm my order button
	Then I click on the my username on the top right hand side of the site
	Then I click on Order history and details and click on details link in next page
	Then I see that the order for the product is referenced on the page

Scenario: Update Personal Information (First Name) in My Account
	Given I am on the site http://automationpractice.com/
	And I login with my credentials
	When I click on My personal information link
	And I enter the updated FirstName
	And I enter the user password
	And I click on Save button
	Then I see the message that the first name has been updated 