require(devtools)
devtools::document(roclets=c('rd', 'collate', 'namespace'))
packPath <- devtools::build(binary = TRUE, args = c('--preclean'))
print (packPath)
install.packages(packPath , repos = NULL, type = "source")

file.copy(packPath, "dist", overwrite = TRUE)

