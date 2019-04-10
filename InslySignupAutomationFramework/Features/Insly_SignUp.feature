Feature: Insly_SignUp

@SmokeTest
Scenario: verify Signup Page
	Given Go to Sign Up page of Insly
	Then Sign up and start using- title is shown there
	When Fill some random unique name in Company name
	Then All data filled in
	Then Chose any country
	And Check address e.g.yourname.incly.com
	Then Select any Company profile
	Then Select any Number of Employees
	Then Select any HOW WOULD YOU DESCRIBE YOURSELF?
	Then Move to Administrator account details block
	And Fill in Work e-mail
	And Fill in Acount Mangaer
    And Press suggest a Secure password and remember it
	Then Enter your phone number
	And Move to Terms and Conditions Section and Tick all Terms and conditions
	Then Click on terms and conditions link and agree
	Then Click on privacy policy link and scroll down, close popup
	Then Sign up button get Active
	Then Press Sign up button
	Then Wait for instance creation finish
	Then Url is same as companyName.insly.com
	And User is logged in 
	


	
	     





	

	 
