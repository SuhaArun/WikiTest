Feature: Wikipedia Search

  Scenario Outline: Wiki Search in English
    Given a web browser is at the Wiki home page
    When user searches <searchstring> in English 
    Then the result page with <searchstring> heading is displayed
	
	Examples:
	| searchstring |
	| Selenium   |
	| Television |


	Scenario Outline: Wiki Search in diff Lang
    Given a web browser is at the Wiki home page
    When user searches a "Television" in any <lang>
    Then the search result page is available in that <lang>
	And the result page should have English language link available
	
	Examples:
	| lang |
	| fr |
	| es |
	| en |


 