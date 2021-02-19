package cr.ac.ucr.api.controller;


import cr.ac.ucr.api.model.Issue;
import cr.ac.ucr.api.service.IssueService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@CrossOrigin(origins = "http://localhost:4200")
@RestController
@RequestMapping(path = "/api/issue")
public class IssueController {
    @Autowired
    private IssueService service;
    @GetMapping("/issues")
    public List<Issue> list() {
        return service.listAll();
    }

    @GetMapping("/issues/{id}")
    public ResponseEntity<Issue> get(@PathVariable Integer id) {
        try {
            Issue issue = service.get(id);
            return new ResponseEntity<Issue>(issue, HttpStatus.OK);
        } catch (NoSuchElementException e) {
            return new ResponseEntity<Issue>(HttpStatus.NOT_FOUND);
        }
    }

    @PostMapping("/add")
    public void add(@RequestBody Issue issue) {
        service.save(issue);
    }

    @PutMapping("/update/")
    public ResponseEntity<Issue> update(@RequestBody Issue issue) {
        try {
            service.save(issue);
            return new ResponseEntity<Issue>(issue, HttpStatus.OK);
        } catch (NoSuchElementException e) {
            return new ResponseEntity<Issue>(HttpStatus.NOT_FOUND);
        }
    }

    @DeleteMapping("/delete/{id}")
    public void delete(@PathVariable Integer id) {
        service.delete(id);
    }
}
