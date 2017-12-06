infile = open("./debugOutput/addchild.csv", "r")

for line in infile:
    if "Add Child" in line:
        print line