import pandas as pd



def readInCSV():

    #const
    sexChoice = 2
    type = "Weight"

    df = pd.read_csv("data/wtageinf.csv");
    percentileCols = ["P3",	"P5","P10",	"P25",	"P50",	"P75",	"P90",	"P95", "P97"]

    for item in percentileCols:
        dataList = df.loc[df['Sex'] == sexChoice, item].tolist();
        print formatList(sexChoice, dataList, item, type)

def formatList(sexChoice, list, percentileCols, type):
    genderString = "Male"
    if sexChoice == 2:
        genderString = "Female";

    Category = percentileCols + genderString + type
    listString = ','.join(str(e) for e in list);
    template = "public static List < double >" + Category +  "= new List < double >(new double[] {" + listString + "});"
    return template

if __name__ == "__main__":
  readInCSV()