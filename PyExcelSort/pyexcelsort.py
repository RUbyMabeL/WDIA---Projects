import pylightxl as xl

with open('cities.xlsx', 'rb') as f:
    db = xl.readxl(f)

l = list(db.ws(ws='Sheet1').col(col=3))

#ask the user for the code of the country and save it into a variable
d = {}
for el in l:
    EL = el.upper()
    if EL in d:
        d[EL]=d[EL]+1
    else:
        d[EL]=1

#Scan the list l line by line and add 1 to the counter if the country is the one looked for
country = input("Enter the Country Code:")
nCountryCode = 0
for el in l:
    if el == country:
        nCountryCode += 1

#Format and print the result
print("There are {} cities in {}".format(nCountryCode,country))

#Ask the user for the population looked for. Use a loop and a try except to validate the input as a valid integer
done = False
while done == False:
    try:
        pop = int(input("Enter the population:"))
        done = True
    except:
        print("That is not a valid number, please re-enter.")

#Store the population values into a list called l1 (see line 6)
l1 = list(db.ws(ws='Sheet1').col(col=5))

#Initialize a list lstOfRecords to an empty list
lstOfRecords = []

#Scan the list l1, if the population is larger than the population looked for, add the list index to lstOfRecords
for el in l1:
    if el > pop:
        lstOfRecords.append(l1.index(el))

#Print the list lstOfRecords
lstOfRecordsLen = len(lstOfRecords)
print("There are {} cities have more population than that number.".format(lstOfRecordsLen))

#Bonus: Print the name of the cities whose index is in listOfRecords
cityList = list(db.ws(ws="Sheet1").col(col=2))
cityRecord = []
index = 0
for i in lstOfRecords:
    cityRecord.append(cityList[i])
print(cityRecord)
