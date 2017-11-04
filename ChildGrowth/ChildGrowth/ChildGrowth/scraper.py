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
    df = pd.read_csv("data/milestones.csv", names = ['Month', 'Category', 'Description','URL']);
    Month = df['Month'].tolist()
    Category = df['Category'].tolist()
    Description = df['Description'].tolist()
    URL = df['URL'].toList()

    for i in range(len(Month)):
        print "milestonesInfo.Add(new MilestonesInfo {MonthDue =", Month[i], ",CategoryName = ", '"%s"'%Category[i], ", CategoryDescription = ",'"%s"'%Description[i], "});"

if __name__ == "__main__":
  # readInCSV()
    readMilestones();