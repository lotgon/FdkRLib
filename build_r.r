require(devtools)
devtools::document(roclets=c('rd', 'collate', 'namespace'))
devtools::build(binary = TRUE, args = c('--preclean'))