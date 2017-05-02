At www.seafoodwatch.org we needed a utility to parse out search terms entered by users of our Seafood Recommendation search. If a person entered "Wild Southern Bluefin Tuna" we needed to determine if they wanted to find Tuna of type "Southern Bluefin" that was wild as opposed to farmed, or instead, if there were meaningful search results for "Wild Southern", "Southern Bluefin", or "Bluefin Tuna". Simple strings don't carry metadata to match them against our internal species, groups, or aquaculture types.

As a solution, I wrote the TermsIterator.cs utility in this repo to parse out the search terms into word groups which were then, one at a time, tested against our search index. The above "Wild Southern Bluefin Tuna" would parse as follows:

"Wild Southern Bluefin Tuna"<br/>
"Wild Southern Bluefin"<br/>
"Southern Bluefin Tuna"<br/>
"Wild Southern"<br/>
"Southern Bluefin"<br/>
"Bluefin Tuna"<br/>
"Wild"<br/>
"Southern"<br/>
"Bluefin"<br/>
"Tuna"<br/>

This "divide and match" approach allowed us to determine meaningful terms of "Wild" caught, "Southern Bluefin" type, and "Tuna" group.

This utility was written with a test-first approach and all tests are included in the repo. It utilizes C# Linq statements and a couple of simple C# extension methods which are also here. It was fun to create this bit of code.
