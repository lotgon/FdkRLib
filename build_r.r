require(roxygen2)
require(devtools)
setwd("RPackage")
devtools::document(roclets=c('rd', 'collate', 'namespace'))
packPath <- devtools::build(binary = TRUE, args = c('--preclean'))


