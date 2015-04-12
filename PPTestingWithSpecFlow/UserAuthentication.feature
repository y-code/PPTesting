@mytag
Feature: User Authentication

Scenario: A user successfully login.
  Given Login Page is displayed on the browser
  When you enter the following inputs
    | User Name   | Password |
    | yasu.gemini | 1234     |
  And you click Login Button
  Then Admin Page is displayed on the browser

Scenario: A user fails to log in with a wrong password.
  Given Login Page is displayed on the browser
  When you enter the following inputs
    | User Name   | Password |
    | yasu.gemini | 4567     |
  And you click Login Button
  Then Login Page is displayed on the browser
  And Login Error Message says "Invalid username and/or password" on the web page

Scenario: A user fails to log in with a wrong user name.
  Given Login Page is displayed on the browser
  When you enter the following inputs
    | User Name   | Password |
    | yasu.gemini | 4567     |
  And you click Login Button
  Then Login Page is displayed on the browser
  And Login Error Message says "Invalid username and/or password" on the web page
