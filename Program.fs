open System
open FSharp.Data

(* Steps:
   - Go to http://www.meetup.com/fsharpsydney/
   - Go to the current meeting
   - Go to the "Tools" dropdownlist on the top on the right side and select "Download attendee list"
   - Open the file with excel and save it as .csv (e.g. FSharp-May.csv)
   - Update the "filePath" literal in the current file to point to csv file instead of Sample.csv (e.g. let filePath = @"C:\Downloads\FSharp-April.csv") 
   - Run the app *)

[<Literal>]
let filePath = @"Sample.csv"
type Meeting = CsvProvider<filePath>

[<EntryPoint>]
let main argv = 

    let membersToExclude = ["Jorge Fioranelli"; "Hadi Eskandari"; "Aaron Powell"]
    let meeting = Meeting.Load filePath
    let members = [for row in meeting.Rows do 
                    if not (membersToExclude |> List.exists ((=)row.Name)) then
                     yield row.Name]
    let rnd = System.Random ()
    members |> Random.getMember rnd
    