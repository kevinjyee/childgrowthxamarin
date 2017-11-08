import pandas as pd



def readInCSV():

    #const
    sexChoice = 1
    type = "HeadC"

    df = pd.read_csv("data/hcageinf.csv");

    percentileCols = ["P3",	"P5","P10",	"P25",	"P50",	"P75",	"P90",	"P95", "P97"]

    for item in percentileCols:
        dataList = df.loc[df['Sex'] == sexChoice, item].tolist();
        #print dataList
        print formatList(sexChoice, dataList, item, type)

def formatList(sexChoice, list, percentileCols, type):
    genderString = "Male"
    if sexChoice == 2:
        genderString = "Female";

    Category = percentileCols + genderString + type
    listString = ','.join(str(e) for e in list);
    template = "public static List < double >" + Category +  "= new List < double >(new double[] {" + listString + "});"
    return template


def readMilestones():
    df = pd.read_csv("data/milestonesEdit2CSV.csv", names = ['ID','Month', 'Category', 'Description','URL']);
    ID = df['ID'].tolist()
    Month = df['Month'].tolist()
    Category = df['Category'].tolist()
    Description = df['Description'].tolist()
    URL = df['URL'].tolist()

    for i in range(len(Month)):
        #print "milestonesInfo.Add(new MilestonesInfo {MonthDue =", Month[i], ",CategoryName = ", '"%s"'%Category[i], ", CategoryDescription = ",'"%s"'%Description[i],", ImageURL = ",'"%s"'%URL[i], "});"
        print "Milestones.Add(new MilestoneBuilder().WithID("+str(ID[i])+ ").WithCategory(" + str(Category[i])+").WithHelpfulText(",'"" ', ").WithQuestionText(",'"%s"'%Description[i],").WithMilestoneDueDate("+str(Month[i]) + ").WithMedia(new Models.MediaUtil.Media(",'"%s"'%URL[i],")).Build());"

def readVaccines():
    df = pd.read_csv("data/vaccines.csv", names=['ID', 'Name', 'Info', 'Time']);
    ID = df['ID'].tolist()
    Name = df['Name'].tolist()
    Info = df['Info'].tolist()
    Time = df['Time'].tolist()

    for i in range(len(ID)):
        #print "Vaccines.Add(new VaccinationTable() { VaccinationID = " + str(ID[i]) + " , Name = ",'"%s"'%Name[i],",Info =", '"%s"'%Info[i], ",Time = " + str(Time[i]) + "});"

        print "VaccineBuilder().WithID("+str(ID[i])+ ").WithVaccineDueDate("+str(Time[i])+".WithInfo(",'"%s"'%Info[i],").WithVaccineName(" ,'"%s"'%Name[i], ").Build());"
if __name__ == "__main__":
  # readInCSV()
    readMilestones()