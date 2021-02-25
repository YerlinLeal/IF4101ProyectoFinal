package cr.ac.ucr.api.controller;

import cr.ac.ucr.api.model.Issue;
import cr.ac.ucr.api.model.IssueDTO;
import cr.ac.ucr.api.restClient.IssueRestClient;
import cr.ac.ucr.api.service.IssueService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Date;
import java.util.List;
import java.util.NoSuchElementException;

@CrossOrigin(origins = "http://localhost:4200")
@RestController
@RequestMapping(path = "/api/issue")
public class IssueController {
    @Autowired
    private IssueService service;

    @GetMapping("/issues2/{id}")
    public List<Issue> list(@PathVariable Integer id) {

        return service.listAll(id);
    }

    @GetMapping("/issues/{report_Number}")
    public ResponseEntity<Issue> get(@PathVariable Integer report_Number) {
        try {
            Issue issue = service.get(report_Number);
            return new ResponseEntity<Issue>(issue, HttpStatus.OK);
        } catch (NoSuchElementException e) {
            return new ResponseEntity<Issue>(HttpStatus.NOT_FOUND);
        }
    }

    @PostMapping("/add")
    public ResponseEntity<Issue> add(@RequestBody Issue issue) {
        try {
            Date now = new Date();
            issue.setCreation_Date(now);
            issue.setModify_Date(now);
            issue.setRegister_Timestamp(now);
            issue.setStatus('I');
            issue.setState(true);
            issue.setModified_By(issue.getCreated_By());

            Issue issueInserted = service.save(issue);
            IssueRestClient restClient = new IssueRestClient();
            restClient.callPostIssueAPI(issueInserted);

            return new ResponseEntity<Issue>(issueInserted, HttpStatus.OK);
        } catch (NoSuchElementException e) {
            return new ResponseEntity<Issue>(HttpStatus.NOT_FOUND);
        }
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

    @DeleteMapping("/delete/{report_Number}")
    public void delete(@PathVariable Integer report_Number) {
        service.delete(report_Number);
    }

    @GetMapping("/getReportData/{report_Number}")
    public ResponseEntity<IssueDTO> getReportData(@PathVariable Integer report_Number){
        try {
            IssueDTO issue = service.getReportData(report_Number);
            return new ResponseEntity<IssueDTO>(issue, HttpStatus.OK);
        } catch (NoSuchElementException e) {
            return new ResponseEntity<IssueDTO>(HttpStatus.NOT_FOUND);
        }
    }

}
