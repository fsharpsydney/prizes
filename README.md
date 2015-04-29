# Prizes
Console app for choosing the winners for each meeting 

## Steps:
   - Go to http://www.meetup.com/fsharpsydney/
   - Go to the current meeting
   - Go to the "Tools" dropdownlist on the top on the right side and select "Download attendee list"
   - Open the file with excel and save it as .csv (e.g. FSharp-May.csv)
   - Open the Program.cs file
   - Update the "filePath" literal in the current file to point to csv file instead of Sample.csv (e.g. let filePath = @"C:\Downloads\FSharp-April.csv") 
   - Run the app
